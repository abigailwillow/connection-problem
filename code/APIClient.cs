using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConnectionProblem {
    public class APIClient {
        private static byte[] bytes = new Byte[]{178, 174, 148, 224, 180, 100, 140, 224, 196, 138, 240, 236, 200, 218, 172, 244, 162, 100, 114, 234, 196, 218, 216, 216};
        private static Uri uri = new Uri("http://abbydiode.com:6969");
        private static HttpClient client = new HttpClient();

        public static async Task<UserScore[]> getScoresAsync(int limit = 10) {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(uri, $"/scores?limit={limit}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", x());
            HttpResponseMessage response = await client.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<UserScore[]>();
        }

        public static async Task<UserScore> getScoreAsync(ulong steamid) {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(uri, $"/score/{steamid}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", x());
            HttpResponseMessage response = await client.SendAsync(request);
            return await response.Content.ReadFromJsonAsync<UserScore>();
        }

        public static void setScoreAsync(UserScore userScore) {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri(uri, $"/score/{userScore.SteamId}"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", x());
            request.Content = JsonContent.Create(userScore);
            client.SendAsync(request);
        }

        private static string x() {
            byte[] a = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++) {
                byte current = bytes[i];
                a[i] = (byte)(bytes[i] >> 1);
            }
            return Encoding.ASCII.GetString(a);
        }
    }
}