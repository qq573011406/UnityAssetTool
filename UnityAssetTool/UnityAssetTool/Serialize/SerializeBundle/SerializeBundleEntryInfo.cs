﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityAssetTool
{
    class SerializeBundleEntry : SerializeDataStruct
    {
        public string name;
        public uint offset;
        public uint size;
        public byte[] assetData;
        public override void DeSerialize(DataReader data)
        {
            name = data.ReadStringNull();
            offset = data.ReadUint32();
            size = data.ReadUint32();
            assetData = data.GetRangeBytes(offset, size);
            
        }
    }
}
