using System.Activities;

namespace TroyWeb.TwilioAPI.Activities.Properties
{
    public static class CodeActivityMetadataExtensions
    {
        public static void AddRequiredArgument(this CodeActivityMetadata metadata, Argument argument, string argumentName)
        {
            if (argument == null) metadata.AddValidationError(string.Format(Resources.ValidationValue_Error, argumentName));
        }

        public static void AddMutuallyExclusiveArguments(this CodeActivityMetadata metadata, Argument argument1, string argument1name, Argument argument2, string argument2name)
        {
            if (argument1 != null && argument2 != null)
            {
                metadata.AddValidationError(string.Format(Resources.ValidationExclusiveProperties_Error, argument1name, argument2name));
            }
        }

        public static void AddComplementaryArguments(this CodeActivityMetadata metadata, Argument argument1, string argument1name, Argument argument2, string argument2name)
        {
            if ((argument1 != null && argument2 != null) || (argument1 == null && argument2 == null))
            {
                return;
            }
            metadata.AddValidationError(string.Format(Resources.ValidationOverloadGroup_Error, argument1name, argument2name));
        }

        public static void AddComplementaryArguments(this CodeActivityMetadata metadata, Argument argument1, string argument1name, Argument argument2, string argument2name, Argument argument3, string argument3name)
        {
            if ((argument1 != null && argument2 != null && argument3 == null) ||
                (argument1 != null && argument2 == null && argument3 != null) || 
                (argument1 != null && argument2 != null && argument3 == null) ||
                (argument1 == null && argument2 == null && argument3 == null))
            {
                return;
            }

            metadata.AddValidationError(string.Format(Resources.ValidationGroupDependant_Error, argument1name, string.Format(Resources.ValidationExclusiveProperties_Error, argument2name, argument3name)));
        }
    }
}
