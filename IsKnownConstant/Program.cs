using System.Reflection;
using System.Runtime.CompilerServices;

namespace IsKnownConstant
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"{nameof(CallerMethodWithConstants)} [ {nameof(ConstantHelpers.IsKnownConstant)}: {CallerMethodWithConstants()} ]");

            Console.WriteLine($"{nameof(CallerMethodWithNonConstantType)} [ {nameof(ConstantHelpers.IsKnownConstant)}: {CallerMethodWithNonConstantType()} ]");
        }

        // The constant folding doesn't happen in T0 compilation
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool CallerMethodWithConstants()
        {
            return
                InlinedMethod(69) &&
                InlinedMethod("Hello") &&
                InlinedMethod('A') &&
                InlinedMethod(typeof(Program));
        }

        // We try to access this class via reflection, so it shouldn't result in a constant type
        private sealed class FooBar;

        // The constant folding doesn't happen in T0 compilation
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static bool CallerMethodWithNonConstantType()
        {
            return InlinedMethod(
                typeof(Program).GetNestedType(
                    name: nameof(FooBar),
                    bindingAttr: unchecked((BindingFlags) (-1))
                )
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InlinedMethod(string value)
        {
            return ConstantHelpers.IsKnownConstant(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InlinedMethod(char value)
        {
            return ConstantHelpers.IsKnownConstant(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InlinedMethod(Type? value)
        {
            return ConstantHelpers.IsKnownConstant(value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool InlinedMethod<T>(T value) where T: struct
        {
            return ConstantHelpers.IsKnownConstant(value);
        }
    }
}