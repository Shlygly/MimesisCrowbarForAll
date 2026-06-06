using ItemsAPI.Builders;
using ItemsAPI.Descriptors;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(CrowbarForAll.CrowbarForAll), "CrowbarForAll", "0.1.0", "Shlygly", null)]
[assembly: MelonGame("ReLUGames", "MIMESIS")]

namespace CrowbarForAll
{
    public class CrowbarForAll : MelonMod
    {
        public override void OnInitializeMelon()
        {
            VendingMachineDescriptor vendingMachine = new(
                2900,
                180,
                new Vector3(-7.14099979f, 0.332000017f, 31.0699997f),
                new Quaternion(0, -0.840762675f, 0, 0.54140389f)
            )
            {
                ItemYOffset = 0.2f,
                ItemXRotation = 60f,
                ItemScale = 1.5f
            };
            VendingMachineBuilder.RegisterVendingMachine(vendingMachine);
        }
    }
}