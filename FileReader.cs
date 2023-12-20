using System.IO;
using System.Text;

namespace DokaponFileReader
{
    public class DokaponFileReader
    {
        public FileStream fileStream;
        public bool[] byteRead;
        public UInt32 fileOffset;

        public DokaponFileReader(string path)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            fileStream = File.Open(path, FileMode.Open);
            byteRead = new bool[fileStream.Length];
            fileOffset = 0;
        }

        public int Read(ref byte[] buffer, bool reread = false)
        {
            while (!reread && fileStream.Position < fileStream.Length && byteRead[fileStream.Position] == true)
                fileStream.Position++;

            if (fileStream.Position >= fileStream.Length)
                return 0;

            var currentPosition = fileStream.Position;
            var result = fileStream.Read(buffer);

            for (int i = 0; i < buffer.Length; i++)
                byteRead[currentPosition + i] = true;

            return result;
        }

        public byte GetByte(bool reread = false)
        {
            byte[] buffer = new byte[1];
            Read(ref buffer, reread);

            return buffer[0];
        }

        public UInt16 GetUInt16(bool reread = false)
        {
            byte[] buffer = new byte[2];
            Read(ref buffer, reread);

            return BitConverter.ToUInt16(buffer);
        }

        public Int16 GetInt16(bool reread = false)
        {
            byte[] buffer = new byte[2];
            Read(ref buffer, reread);

            return BitConverter.ToInt16(buffer);
        }

        public UInt32 GetUInt32(bool reread = false)
        {
            byte[] buffer = new byte[4];
            Read(ref buffer, reread);

            return BitConverter.ToUInt32(buffer);
        }

        public Int32 GetInt32(bool reread = false)
        {
            byte[] buffer = new byte[4];
            Read(ref buffer, reread);

            return BitConverter.ToInt32(buffer);
        }

        public string GetString(int bytesToRead = 4, bool reread = false)
        {
            byte[] buffer = new byte[bytesToRead];
            string result = String.Empty;

            do
            {
                Read(ref buffer, reread);
                result += Encoding.GetEncoding(932).GetString(buffer);
            } while (!buffer.ToList().Contains(0));

            return result;
        }
        public string GetStringAtPosition(UInt32 position, int bytesToRead = 4, bool reread = false)
        {
            var currentPosition = Position();

            SetPosition(position + fileOffset);
            string result = GetString(bytesToRead, reread);
            SetPosition(currentPosition);

            return result;
        }

        public List<string> GetStringListAtPosition(UInt32 position, int bytesToRead = 4, bool reread = false)
        {
            List<string> result = new List<string>();
            byte[] buffer = new byte[bytesToRead];

            var currentPosition = Position();
            SetPosition(position + fileOffset);
            do
            {
                result.Add(GetString(2, reread));
            } while (result.Last().Length > bytesToRead);

            while (Position() % 4 != 0)
                Read(ref buffer, reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<string> GetStringListAtSection(UInt32 sectionStart, UInt32 sectionEnd, int bytesToRead = 4, bool reread = false)
        {
            List<string> result = new List<string>();

            var currentPosition = Position();
            SetPosition(sectionStart + fileOffset);

            while (Position() < sectionEnd + fileOffset)
                result.Add(GetString(bytesToRead, reread));

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteList(bool reread = false)
        {
            List<byte> result = new List<byte>();

            do
            {
                result.Add(GetByte(reread));
            } while (result.Last() != 0xFF);

            while (Position() % 4 != 0)
                GetByte(reread);

            return result;
        }

        public List<byte> GetByteListWithTokenCount(UInt32 position, byte endToken, int tokenCount, bool reread = false)
        {
            List<byte> result = new List<byte>();
            int count = 0;
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            do
            {
                result.Add(GetByte(reread));

                if (result.Last() == endToken)
                    count++;

            } while (count < tokenCount);

            while (Position() % 4 != 0)
                GetByte();

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<byte> result = GetByteList(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<byte> GetByteListAtSection(UInt32 setctionStart, UInt32 sectionEnd, bool reread = false)
        {
            List<byte> result = new List<byte>();

            var currentPosition = Position();
            SetPosition(setctionStart + fileOffset);

            while (Position() < sectionEnd + fileOffset)
                result.Add(GetByte(reread));

            while (Position() % 4 != 0)
                GetByte(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<UInt16> GetUInt16List(bool reread = false)
        {
            List<UInt16> result = new List<UInt16>();

            do
            {
                result.Add(GetUInt16(reread));
            } while (((byte)result.Last()) != 0xFF);

            while (Position() % 4 != 0)
                result.Add(GetUInt16(reread));

            return result;
        }

        public List<UInt16> GetUInt16ListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<UInt16> result = GetUInt16List(reread);

            SetPosition(currentPosition);

            return result;
        }

        public List<UInt32> GetUInt32List(bool reread = false)
        {
            List<UInt32> result = new List<UInt32>();

            do
            {
                result.Add(GetUInt32(reread));
            } while (result.Last() != 0);

            return result;
        }

        public List<UInt32> GetUInt32ListAtPosition(UInt32 position, bool reread = false)
        {
            var currentPosition = Position();
            SetPosition(position + fileOffset);

            List<UInt32> result = GetUInt32List(reread);

            SetPosition(currentPosition);

            return result;
        }

        public void Close()
        {
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

        public bool PositionAlreadyRead(long position)
        {
            if (position < 0 || position > byteRead.Length)
                return true;

            return byteRead[position];
        }
    }
}
