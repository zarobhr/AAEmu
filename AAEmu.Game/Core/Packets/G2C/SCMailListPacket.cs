using AAEmu.Commons.Network;
using AAEmu.Game.Core.Network.Game;
using AAEmu.Game.Models.Game.Mails;

namespace AAEmu.Game.Core.Packets.G2C
{
    public class SCMailListPacket : GamePacket
    {
        private readonly bool _isSent;
        private readonly Mail[] _mails;

        public SCMailListPacket(bool isSent, Mail[] mails) : base(0x113, 1)
        {
            _isSent = isSent;
            _mails = mails;
        }

        public override PacketStream Write(PacketStream stream)
        {
            stream.Write(_isSent);
            stream.Write(_mails.Length);
            foreach (var mail in _mails)
                stream.Write(mail);
            return stream;
        }
    }
}