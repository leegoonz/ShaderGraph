using System.Reflection;

namespace UnityEditor.ShaderGraph
{
    [Title("Math", "Vector", "Rejection")]
    public class RejectionNode : CodeFunctionNode
    {
        public RejectionNode()
        {
            name = "Rejection";
        }

        protected override MethodInfo GetFunctionToConvert()
        {
            return GetType().GetMethod("Unity_Rejection", BindingFlags.Static | BindingFlags.NonPublic);
        }

        static string Unity_Rejection(
            [Slot(0, Binding.None)] DynamicDimensionVector A,
            [Slot(1, Binding.None)] DynamicDimensionVector B,
            [Slot(2, Binding.None)] out DynamicDimensionVector Out)
        {
            return
                @"
{
    Out = A - (B * dot(A, B) / dot(B, B));
}
";
        }
    }
}
