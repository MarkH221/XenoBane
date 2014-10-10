using Ionic.Zlib;
using Isolib.IOPackage;
using System.Collections.Generic;

namespace XCOMSE.Classes
{
    public class SaveData
    {
        /// <summary>
        ///     The Magic number for a compressed block
        /// </summary>
        public readonly uint Magic;

        /// <summary>
        ///     Used during Compression/Decompression operations to segment the data.
        /// </summary>
        public List<byte[]> Block = new List<byte[]>();

        /// <summary>
        ///     The workspace in which data is manipulated.
        /// </summary>
        public byte[] Buffer;

        /// <summary>
        ///     The initial 1024 bytes containing version, timestamps and misc data like dlc and language version.
        /// </summary>
        public byte[] Header;

        /// <summary>
        ///     The last compressed blocks uncompressed length, often not like the others.
        /// </summary>
        public uint LastBlockLength;

        public SaveData(byte[] buffer)
        {
            using (var br = new Reader(buffer, true))
            {
                Header = br.ReadBytes(0x400);
                Magic = br.ReadUInt32();
                long[] results = br.SearchHexString(Magic.ToString("X8"), false);
                // Block (results.Count());
                foreach (long t in results)
                {
                    //determine block length via clength then read it to list.
                    br.Position = t + 0x10;
                    uint clength = br.ReadUInt32();
                    uint dlength = br.ReadUInt32();
                    //This part is platform specific, need to add a check for this later
                    Block.AddRange(new[] {ZlibStream.UncompressBuffer(br.ReadBytes((int) clength))});
                }
                var b = new List<byte>();
                foreach (var t in Block)
                {
                    //Merge the decompressed blocks together.
                    b.AddRange(t);
                }
                Buffer = b.ToArray();
                //Renew blocklist, old data's useless now.
                Block = new List<byte[]>();
            }
        }
    }
}