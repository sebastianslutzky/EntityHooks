﻿namespace System.Data.Entity.Hooks.Fluent.Internal
{
    /// <summary>
    /// Setup for a hook, that should be called when entity satisfies specified condition.
    /// </summary>
    /// <typeparam name="T">Type of the entity.</typeparam>
    internal sealed class SaveConditionalSetup<T> : ConditionalSetup<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SaveConditionalSetup{T}"/> class.
        /// </summary>
        /// <param name="dbHookRegistrar">The database hook registrar.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="entityState">State of the entity.</param>
        public SaveConditionalSetup(IDbHookRegistrar dbHookRegistrar, Predicate<T> predicate, EntityState entityState)
            : base(dbHookRegistrar, predicate, entityState)
        {
        }

        /// <summary>
        /// Called when one more condition is set up.
        /// </summary>
        /// <param name="dbHookRegistrar">The database hook registrar.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="entityState">State of the entity.</param>
        /// <returns>The setup for a hook.</returns>
        protected override IConditionalSetup<T> OnAnd(IDbHookRegistrar dbHookRegistrar, Predicate<T> predicate, EntityState entityState)
        {
            return new SaveConditionalSetup<T>(dbHookRegistrar, predicate, entityState);
        }

        /// <summary>
        /// Registers the hook.
        /// </summary>
        /// <param name="dbHookRegistrar">The database hook registrar.</param>
        /// <param name="hook">The hook.</param>
        protected override void RegisterHook(IDbHookRegistrar dbHookRegistrar, IDbHook hook)
        {
            dbHookRegistrar.RegisterSaveHook(hook);
        }
    }
}