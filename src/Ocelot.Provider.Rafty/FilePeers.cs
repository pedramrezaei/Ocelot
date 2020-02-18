using System.Collections.Generic;

namespace Ocelot.Provider.Rafty
{
    public class FilePeers
    {
        public FilePeers()
        {
            Peers = new List<FilePeer>();
        }

        public List<FilePeer> Peers { get; set; }
    }
}
