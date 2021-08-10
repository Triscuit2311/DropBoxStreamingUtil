using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Dropbox.Api;

namespace DropboxStreamingUtil
{
    public static class Main
    {
        public static async Task<byte[]> _Download(string path, string apiToken)
        { // ...("/Folder/File.dll", "PBQVCOaLLgEAAAAAAAAAAaXzmK29rXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" )
            var dbx = new DropboxClient(apiToken);
            using (var response = await dbx.Files.DownloadAsync(path))
            {
                return (await response.GetContentAsByteArrayAsync());
            }
        }

        public static GCHandle PinArray(byte[] arr)
        {
            return GCHandle.Alloc(arr, GCHandleType.Pinned);
        }

        public static IntPtr GetAddressOfPinnedArray(GCHandle gcHandle)
        {
            return gcHandle.AddrOfPinnedObject();
        }
        
    }
}