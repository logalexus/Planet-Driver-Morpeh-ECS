using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace ECS.Code.Cars
{
    [System.Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Car : IComponent 
    {
        public float Speed;
        public float RotationSpeed;
        public float VerticalStrength;
    }
}