// <copyright file="AuraAbility.cs" company="Ensage">
//    Copyright (c) 2017 Ensage.
// </copyright>

namespace Ensage.SDK.Abilities
{
    using Ensage.SDK.Extensions;

    public abstract class AuraAbility : PassiveAbility
    {
        protected AuraAbility(Ability abiltity)
            : base(abiltity)
        {
        }

        public virtual float Radius
        {
            get
            {
                return this.Ability.GetCastRange();
            }
        }
    }
}