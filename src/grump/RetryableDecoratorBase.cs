using Polly;

namespace Grump.Core
{
    public abstract class PollyRetryableDecoratorBase<TDecorated, TReturn>
    {
        public ISyncPolicy Policy
        {
            get
            {
                if (_policy == null)
                {
                    return DefaultPolicy;
                }

                return _policy;
            }

        }

        private readonly ISyncPolicy _policy;

        public TDecorated DecoratedInstace { get; private set; }

        protected abstract TReturn RetryableAction();

        protected abstract ISyncPolicy DefaultPolicy { get; }

        public PollyRetryableDecoratorBase(TDecorated decoratedInstace, ISyncPolicy policy) : this(decoratedInstace)
        {
            _policy = policy;
        }

        public PollyRetryableDecoratorBase(TDecorated decoratedInstace)
        {
            DecoratedInstace = decoratedInstace;
        }


        protected internal TReturn TryAction()
        {
            return Policy.Execute(RetryableAction);
        }
    }
}
