using ErrorOr;

namespace BuberBreakfast.ServiceError;

public static class Errors{
    public static class Breakfast{
        public static Error NotFound => Error.NotFound(
            "Breakfast.NotFound",
            "Breakfast not found."
        );
        public static Error InvalidName => Error.NotFound(
            "Breakfast.InvalidName",
            $"The breakfast name length should be between {Models.Breakfast.MinNameLength} and {Models.Breakfast.MaxNameLength} characters."
        );
        public static Error InvalidDescription => Error.NotFound(
            "Breakfast.InvalidName",
            $"The breakfast name length should be between {Models.Breakfast.MinDescriptionLength} and {Models.Breakfast.MaxDescriptionLength} characters."
        );
    }
}