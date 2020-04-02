using System;
using System.Activities;
using System.Threading;
using System.Threading.Tasks;
using System.Activities.Statements;
using System.ComponentModel;
using TroyWeb.TwilioAPI.Activities.Properties;
using UiPath.Shared.Activities;
using UiPath.Shared.Activities.Localization;
using TroyWeb.TwilioAPI.Wrappers;

namespace TroyWeb.TwilioAPI.Activities
{
    [LocalizedDisplayName(nameof(Resources.TwilioApiScope_DisplayName))]
    [LocalizedDescription(nameof(Resources.TwilioApiScope_Description))]
    public class TwilioApiScope : ContinuableAsyncNativeActivity
    {
        #region Properties

        [Browsable(false)]
        public ActivityAction<IObjectContainer> Body { get; set; }

        /// <summary>
        /// If set, continue executing the remaining activities even if the current activity has failed.
        /// </summary>
        [LocalizedCategory(nameof(Resources.Common_Category))]
        [LocalizedDisplayName(nameof(Resources.ContinueOnError_DisplayName))]
        [LocalizedDescription(nameof(Resources.ContinueOnError_Description))]
        public override InArgument<bool> ContinueOnError { get; set; }

        [LocalizedDisplayName(nameof(Resources.TwilioApiScope_AccountSid_DisplayName))]
        [LocalizedDescription(nameof(Resources.TwilioApiScope_AccountSid_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AccountSid { get; set; }

        [LocalizedDisplayName(nameof(Resources.TwilioApiScope_AuthToken_DisplayName))]
        [LocalizedDescription(nameof(Resources.TwilioApiScope_AuthToken_Description))]
        [LocalizedCategory(nameof(Resources.Input_Category))]
        public InArgument<string> AuthToken { get; set; }

        [LocalizedDisplayName(nameof(Resources.TwilioApiScope_Region_DisplayName))]
        [LocalizedDescription(nameof(Resources.TwilioApiScope_Region_Description))]
        [LocalizedCategory(nameof(Resources.Options_Category))]
        public InArgument<string> Region { get; set; }

        [LocalizedDisplayName(nameof(Resources.TwilioApiScope_Timeout_DisplayName))]
        [LocalizedDescription(nameof(Resources.TwilioApiScope_Timeout_Description))]
        [LocalizedCategory(nameof(Resources.Options_Category))]
        public InArgument<TimeSpan?> Timeout { get; set; }

        // A tag used to identify the scope in the activity context
        internal static string ParentContainerPropertyTag => "ScopeActivity";

        // Object Container: Add strongly-typed objects here and they will be available in the scope's child activities.
        private readonly IObjectContainer _objectContainer;

        #endregion


        #region Constructors

        public TwilioApiScope(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            Body = new ActivityAction<IObjectContainer>
            {
                Argument = new DelegateInArgument<IObjectContainer> (ParentContainerPropertyTag),
                Handler = new Sequence { DisplayName = Resources.Do }
            };
        }

        public TwilioApiScope() : this(new ObjectContainer())
        {

        }

        #endregion


        #region Protected Methods

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            if (AccountSid == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(AccountSid)));
            if (AuthToken == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, nameof(AuthToken)));

            base.CacheMetadata(metadata);
        }

        protected override async Task<Action<NativeActivityContext>> ExecuteAsync(NativeActivityContext  context, CancellationToken cancellationToken)
        {
            // Inputs
            var accountsid = AccountSid.Get(context);
            var authtoken = AuthToken.Get(context);
            var region = Region.Get(context);
            var timeout = Timeout.Get(context);

            _objectContainer.Add(TwilioWrappers.GetTwilioRestClient(accountsid, authtoken, region, timeout));

            return (ctx) => {
                // Schedule child activities
                if (Body != null)
				    ctx.ScheduleAction<IObjectContainer>(Body, _objectContainer, OnCompleted, OnFaulted);

                // Outputs
            };
        }

        #endregion


        #region Events

        private void OnFaulted(NativeActivityFaultContext faultContext, Exception propagatedException, ActivityInstance propagatedFrom)
        {
            faultContext.CancelChildren();
            Cleanup();
        }

        private void OnCompleted(NativeActivityContext context, ActivityInstance completedInstance)
        {
            Cleanup();
        }

        #endregion


        #region Helpers
        
        private void Cleanup()
        {
            var disposableObjects = _objectContainer.Where(o => o is IDisposable);
            foreach (var obj in disposableObjects)
            {
                if (obj is IDisposable dispObject)
                    dispObject.Dispose();
            }
            _objectContainer.Clear();
        }

        #endregion
    }
}

