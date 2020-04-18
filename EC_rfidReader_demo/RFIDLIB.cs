using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDLIB
{
    class rfidlib_def
    {
        //Inventory type 
        public const int AI_TYPE_NEW = 1;   // new antenna inventory  (reset RF power)
        public const int AI_TYPE_CONTINUE = 2;  // continue antenna inventory ;

        // Move position 
        public const int RFID_NO_SEEK = 0;			// No seeking 
        public const int RFID_SEEK_FIRST = 1;					// Seek first
        public const int RFID_SEEK_NEXT = 2;				// Seek next 
        public const int RFID_SEEK_LAST = 3;				// Seek last

        /*
        * Open connection string 
        */
        public const string CONNSTR_NAME_RDTYPE = "RDType";
        public const string CONNSTR_NAME_COMMTYPE = "CommType";

        public const string CONNSTR_NAME_COMMTYPE_COM = "COM";
        public const string CONNSTR_NAME_COMMTYPE_USB = "USB";
        public const string CONNSTR_NAME_COMMTYPE_NET = "NET";

        //HID Param
        public const string CONNSTR_NAME_HIDADDRMODE = "AddrMode";
        public const string CONNSTR_NAME_HIDSERNUM = "SerNum";
        //COM Param
        public const string CONNSTR_NAME_COMNAME = "COMName";
        public const string CONNSTR_NAME_COMBARUD = "BaudRate";
        public const string CONNSTR_NAME_COMFRAME = "Frame";
        public const string CONNSTR_NAME_BUSADDR = "BusAddr";
        //TCP,UDP
        public const string CONNSTR_NAME_REMOTEIP = "RemoteIP";
        public const string CONNSTR_NAME_REMOTEPORT = "RemotePort";

        //HarType
        public const byte OUTPUT_BEER = 0x01;
        public const byte OUTPUT_RELAY = 0x02;
        public const byte OUTPUT_MOS = 0x03;

        public const byte OUTPUT_FLAG_CLOSE = 0x00;
        public const byte OUTPUT_FLAG_OPEN = 0x01;
        public const byte OUTPUT_FLAG_BLINKED = 0x02;


    }
}
