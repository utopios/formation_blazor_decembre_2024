namespace FormationBlazor.Components.Services;

using System;
using System.Collections.Generic;
using System.Linq;

public class EventAggregator
{
    private readonly Dictionary<Type, List<Subscription>> _subscriptions = new();

    // Méthode pour s'abonner à un type d'événement spécifique
    public Subscription Subscribe<TEvent>(Action<TEvent> action)
    {
        var eventType = typeof(TEvent);
        if (!_subscriptions.ContainsKey(eventType))
        {
            _subscriptions[eventType] = new List<Subscription>();
        }

        var subscription = new Subscription(() => Unsubscribe(eventType, action));
        _subscriptions[eventType].Add(new SubscriptionWrapper<TEvent>(action, subscription));
        
        return subscription;
    }

    // Méthode pour publier un événement
    public void Publish<TEvent>(TEvent eventData)
    {
        var eventType = typeof(TEvent);
        if (_subscriptions.ContainsKey(eventType))
        {
            var subscribers = _subscriptions[eventType]
                .Cast<SubscriptionWrapper<TEvent>>()
                .ToList();

            foreach (var subscriber in subscribers)
            {
                subscriber.Action?.Invoke(eventData);
            }
        }
    }

    // Méthode pour se désabonner
    private void Unsubscribe<TEvent>(Type eventType, Action<TEvent> action)
    {
        if (!_subscriptions.ContainsKey(eventType)) return;

        var subscriber = _subscriptions[eventType]
            .Cast<SubscriptionWrapper<TEvent>>()
            .FirstOrDefault(x => x.Action == action);

        if (subscriber != null)
        {
            _subscriptions[eventType].Remove(subscriber);
        }

        if (!_subscriptions[eventType].Any())
        {
            _subscriptions.Remove(eventType);
        }
    }
}

public class Subscription
{
    private readonly Action _unsubscribe;

    public Subscription(Action unsubscribe)
    {
        _unsubscribe = unsubscribe;
    }

    public void Dispose()
    {
        _unsubscribe?.Invoke();
    }
}

public class SubscriptionWrapper<TEvent> : Subscription
{
    public Action<TEvent> Action { get; }

    public SubscriptionWrapper(Action<TEvent> action, Subscription subscription)
        : base(subscription.Dispose)
    {
        Action = action;
    }
}
