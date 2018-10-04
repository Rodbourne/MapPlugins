using UnityEngine;
using System.Collections;
using System.Xml;

class OsmBounds : BaseOsm
{
    public float MinLat { get; private set; }

    public float MaxLat { get; private set; }

    public float MinLon { get; private set; }

    public float MaxLon { get; private set; }

    public Vector3 Center { get; private set; }

    // minlat="28.5929600" minlon="-81.2142700" maxlat="28.5989700" maxlon="-81.2024000"

    public OsmBounds(XmlNode node)
    {
        MinLat = GetAttribute<float>("minlat", node.Attributes);
        MaxLat = GetAttribute<float>("maxlat", node.Attributes);
        MinLon = GetAttribute<float>("minlon", node.Attributes);
        MaxLon = GetAttribute<float>("maxlon", node.Attributes);

        float x = (float)((MercatorProjection.lonToX(MaxLon) + MercatorProjection.lonToX(MinLon)) / 2);
        float y = (float)((MercatorProjection.latToY(MaxLat) + MercatorProjection.latToY(MinLat)) / 2);

        Center = new Vector3(x, 0, y);

    }
}
