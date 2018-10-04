using UnityEngine;
using System.Collections;
using System.Xml;
using System;

class OsmNode : BaseOsm
{
    public ulong ID { get; private set; }

    public float Latitude { get; private set; }
    
    public float Longitude { get; private set; }

    public float X { get; private set; }

    public float Y { get; private set; }

    public OsmNode(XmlNode node)
    {
        ID = GetAttribute<ulong>( "id", node.Attributes);
        Latitude = GetAttribute<float>("lat", node.Attributes);
        Longitude = GetAttribute<float>("lon", node.Attributes);

        X = (float)MercatorProjection.lonToX(Longitude);
        Y = (float)MercatorProjection.latToY(Latitude);
    }


}
