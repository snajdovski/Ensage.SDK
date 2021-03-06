// <copyright file="UpdateHandler.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Handlers
{
    using System;

    public class UpdateHandler : IUpdateHandler
    {
        public UpdateHandler(Action callback, InvokeHandler executor, bool isEnabled = true)
            : this($"{callback?.Method.DeclaringType?.Name}.{callback?.Method.Name}", callback, executor, isEnabled)
        {
        }

        public UpdateHandler(string name, Action callback, InvokeHandler executor, bool isEnabled = true)
        {
            this.Name = name;
            this.Callback = callback;
            this.Executor = executor;
            this.IsEnabled = isEnabled;
        }

        public Action Callback { get; }

        public InvokeHandler Executor { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; }

        public virtual bool Invoke()
        {
            if (!this.IsEnabled)
            {
                return false;
            }

            return this.Executor.Invoke(this.Callback);
        }

        public override string ToString()
        {
            return $"{this.Executor}[{this.Name}]";
        }
    }

    public class UpdateHandler<TEventArgs> : IUpdateHandler<TEventArgs>
    {
        public UpdateHandler(Action<TEventArgs> callback, InvokeHandler<TEventArgs> executor, bool isEnabled = true)
        {
            this.Name = $"{callback?.Method.DeclaringType?.Name}.{callback?.Method.Name}";
            this.Callback = callback;
            this.Executor = executor;
            this.IsEnabled = isEnabled;
        }

        public Action<TEventArgs> Callback { get; }

        public InvokeHandler<TEventArgs> Executor { get; set; }

        public bool IsEnabled { get; set; }

        public string Name { get; }

        public virtual bool Invoke(TEventArgs args)
        {
            if (!this.IsEnabled)
            {
                return false;
            }

            return this.Executor.Invoke(this.Callback, args);
        }

        public override string ToString()
        {
            return $"{this.Executor}[{this.Name}]";
        }
    }
}