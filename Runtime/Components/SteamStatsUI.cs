using Decay.Utilities;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    public class SteamStatsUI : MonoBehaviour {
        [SerializeField] private SteamAvatar _steamAvatar;
        [SerializeField] private TMPro.TMP_Text _steamProfileName;
        [SerializeField] private TMPro.TMP_Text _profileStatus;

        private FriendState _friendState;

        private async void Awake() {
            if (!SteamClient.IsValid) {
                Debug.LogWarning($"Steam isn't valid!");
                return;
            }

            this._steamProfileName?.SetText(SteamClient.Name);

            if (this._steamAvatar != null) {
                this._steamAvatar.SteamId = SteamClient.SteamId;
                await this._steamAvatar.FetchAsync();
            }
        }

        private void Update() {
            if (!SteamClient.IsValid) return;

            if (this._profileStatus != null) {
                if (this._friendState != SteamClient.State) {
                    this._friendState = SteamClient.State;
                    this.UpdateUserStatus();
                }
            }
        }

        private void UpdateUserStatus() {
            this._profileStatus.richText = true;

            var state = SteamClient.State;

            switch (state) {
                case FriendState.Offline:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.gray));
                    break;
                case FriendState.Online:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.green));
                    break;
                case FriendState.Busy:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.red));
                    break;
                case FriendState.Away:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.yellow));
                    break;
                case FriendState.Snooze:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.gray));
                    break;
                case FriendState.LookingToTrade:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.green));
                    break;
                case FriendState.LookingToPlay:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.green));
                    break;
                case FriendState.Invisible:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.gray));
                    break;
                case FriendState.Max:
                    this._profileStatus.SetText(StringFormat.Color(state.ToString(), Color.gray));
                    break;
                default:
                    this._profileStatus.SetText(StringFormat.Color("Unknown", Color.gray));
                    break;
            }
        }
    }
}