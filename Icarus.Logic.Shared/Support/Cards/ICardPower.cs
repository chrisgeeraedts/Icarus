using System;
using Icarus.Logic.Shared;
using Icarus.Logic.Shared.Managers;
using Icarus.Logic.Support.Enums;

namespace Icarus.Logic.Support.Cards
{
    public interface ICardPower
    {
        BaseCard BaseCard { get; set; }
        int PowerTriggerCounter { get; set; }
        Guid UniquePowerId { get; }
        IGameWorldManager GameWorldManager { get; set; }
        bool ActivateAction();
        PowerTrigger PowerTrigger { get; set; }
    }
}