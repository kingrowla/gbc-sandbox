using CoreGraphics;
using MapKit;
using Microsoft.Maui.Maps.Handlers;
using UIKit;

namespace GBC.Tracker;

internal static class FireTruckMapPinHandler
{
    private const string FireTruckPinLabel = "Fire Truck";
    private const string ReuseIdentifier = "FireTruckPin";

    public static void Configure()
    {
        MapHandler.Mapper.AppendToMapping(nameof(FireTruckMapPinHandler),
            static (handler, _) =>
            {
                handler.PlatformView.GetViewForAnnotation += CreateAnnotationView;
            });
    }

    private static MKAnnotationView? CreateAnnotationView(
        MKMapView mapView,
        IMKAnnotation annotation)
    {
        // Preserve MapKit's standard blue user-location indicator.
        if (annotation is MKUserLocation || annotation.GetTitle() != FireTruckPinLabel)
        {
            return null;
        }

        var annotationView = mapView.DequeueReusableAnnotation(ReuseIdentifier)
            ?? new MKAnnotationView(annotation, ReuseIdentifier);

        annotationView.Annotation = annotation;
        annotationView.CanShowCallout = true;
        annotationView.CenterOffset = new CGPoint(0, -24);
        annotationView.Image ??= CreateMarkerImage();

        return annotationView;
    }

    private static UIImage? CreateMarkerImage()
    {
        var source = UIImage.FromBundle("fire_truck.png");

        if (source is null)
        {
            return null;
        }

        var size = new CGSize(48, 48);
        var renderer = new UIGraphicsImageRenderer(size);

        return renderer.CreateImage(_ => source.Draw(new CGRect(CGPoint.Empty, size)));
    }
}
