using System.Threading.Tasks;
using Steamworks;
using Steamworks.ServerList;
using UnityEngine;
using UnityEngine.UI;

namespace pippinmole.UI {
    //
    // To change at runtime set SteamId then call Fetch()
    //
    public class SteamAvatar : MonoBehaviour {
        public ulong SteamId;
        public Texture FallbackTexture;

        public async Task FetchAsync() {
            if (this.SteamId == 0) return;

            var image = await SteamFriends.GetMediumAvatarAsync(this.SteamId);
            this.OnImage(image);
        }

        private void OnImage(Steamworks.Data.Image? image) {
            if (image == null) {
                this.ApplyTexture(this.FallbackTexture);
                return;
            }

            var texture = new Texture2D((int)image.Value.Width, (int)image.Value.Height);

            for (int x = 0; x < image.Value.Width; x++) {
                for (int y = 0; y < image.Value.Height; y++) {
                    var p = image.Value.GetPixel(x, y);

                    texture.SetPixel(x, (int)image.Value.Height - y, new Color(p.r / 255.0f, p.g / 255.0f, p.b / 255.0f, p.a / 255.0f));
                }
            }

            texture.Apply();

            this.ApplyTexture(texture);
        }

        private void ApplyTexture(Texture texture) {
            var rawImage = this.GetComponent<RawImage>();
            if (rawImage != null)
                rawImage.texture = texture;
        }
    }
}