using System;
using System.Collections.Generic;
using UnityEngine;

namespace SonarSpaceship.Data
{
    [Serializable]
    public class ProfileData : IProfileData, ICloneable<ProfileData>
    {
        [SerializeField]
        private string name = string.Empty;

        [SerializeField]
        private List<string> finishedLevels = new List<string>();

        public string Name
        {
            get => name ?? string.Empty;
            set => name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public IEnumerable<string> FinishedLevels => finishedLevels ??= new List<string>();

        public ProfileData()
        {
            // ...
        }

        public ProfileData(string name, IEnumerable<string> finishedLevels)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.finishedLevels = new List<string>(finishedLevels ?? throw new ArgumentNullException(nameof(finishedLevels)));
        }

        public ProfileData Clone() => new ProfileData(Name, (finishedLevels == null) ? new List<string>() : new List<string>(finishedLevels));
    }
}
