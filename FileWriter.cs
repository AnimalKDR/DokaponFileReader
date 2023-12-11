using System.IO;
using System.Text;

namespace DokaponFileReader
{
    public class DokaponFileWriter
    {
        public FileStream fileStream;
        public UInt32 fileOffset;

        public DokaponFileWriter(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            fileStream = File.Create(path);
            fileOffset = 0;
        }

        public void Write(byte[] buffer)
        {
            fileStream.Write(buffer);
        }

        public void Write(byte data)
        {
            fileStream.WriteByte(data);
        }

        public void Write(UInt16 data)
        {
            Write(BitConverter.GetBytes(data));
        }

        public void Write(Int16 data)
        {
            Write(BitConverter.GetBytes(data));
        }

        public void Write(UInt32 data)
        {
            Write(BitConverter.GetBytes(data));
        }

        public void Write(Int32 data)
        {
            Write(BitConverter.GetBytes(data));
        }

        public void WriteString(string data, int alignment = 4)
        {
            byte[] buffer = new byte[2 * data.Length];
            Encoding.GetEncoding(932).GetBytes(data, buffer);

            foreach (byte b in buffer)
            {
                Write(b);

                if (b == 0)
                    break;
            }

            while(fileStream.Position % alignment != 0)
                Write((byte)0);
        }

        public void WriteStringList(List<string> data, int alignment = 4)
        {
            foreach (string str in data)
                WriteString(str, alignment);

            while (Position() % alignment != 0)
                Write((byte)0);
        }

        public void WriteStringAtPosition(string data, UInt32 position, int alignment = 4)
        {
            var currentPosition = Position();

            SetPosition(position + fileOffset);
            WriteString(data, alignment);
            SetPosition(currentPosition);
        }

        public void WriteStringListAtPosition(List<string> data, UInt32 position, int alignment = 4)
        {
            var currentPosition = Position();

            SetPosition(position + fileOffset);

            foreach (string str in data)
                WriteString(str, 2);

            while (Position() % alignment != 0)
                Write((byte)0);

            SetPosition(currentPosition);
        }

        public void WriteByteList(List<byte> data, int alignment = 4)
        {
            foreach(byte b in data)
                Write(b);

            while (Position() % alignment != 0)
                Write((byte)0);
        }

        public void WriteByteListAtPosition(List<byte> data, UInt32 position, int alignment = 4)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);
            WriteByteList(data, alignment);
            SetPosition(currentPosition);
        }

        public void WriteUInt16List(List<UInt16> data, int alignment = 4)
        {
            foreach(UInt16 v in data)
                Write(v);

            while (Position() % alignment != 0)
                Write((byte)0);
        }

        public void WriteUInt16ListAtPosition(List<UInt16> data, UInt32 position, int alignment = 4)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);
            WriteUInt16List(data, alignment);
            SetPosition(currentPosition);
        }

        public void WriteUInt32List(List<UInt32> data)
        {
            foreach (UInt32 v in data)
                Write(v);
        }

        public void WriteUInt32ListAtPosition(List<UInt32> data, UInt32 position)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);
            WriteUInt32List(data);
            SetPosition(currentPosition);
        }

        public void Close()
        {
            fileStream.Flush();
            fileStream.Close();
        }

        public long Position()
        {
            return fileStream.Position;
        }

        public void SetPosition(long position)
        {
            fileStream.Position = position;
        }
    }
}
