using System;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Hosting;

namespace XamlBrewer.Uwp.AdaptiveMenuBarSample
{
    public static partial class ItemsControlExtensions
    {
        public static void RegisterImplicitAnimations(this ItemsControl itemsControl)
        {
            var compositor = ElementCompositionPreview.GetElementVisual(itemsControl as UIElement).Compositor;

            // Create ImplicitAnimations Collection. 
            var elementImplicitAnimation = compositor.CreateImplicitAnimationCollection();

            // Define trigger and animation that should play when the trigger is triggered. 
            elementImplicitAnimation["Offset"] = CreateOffsetAnimation(compositor);

            foreach (SelectorItem item in itemsControl.Items)
            {
                var elementVisual = ElementCompositionPreview.GetElementVisual(item);
                elementVisual.ImplicitAnimations = elementImplicitAnimation;
            }
        }

        public static void RegisterBoundImplicitAnimations(this ItemsControl itemsControl)
        {
            var compositor = ElementCompositionPreview.GetElementVisual(itemsControl as UIElement).Compositor;

            // Create ImplicitAnimations Collection. 
            var elementImplicitAnimation = compositor.CreateImplicitAnimationCollection();

            // Define trigger and animation that should play when the trigger is triggered. 
            elementImplicitAnimation["Offset"] = CreateOffsetAnimation(compositor);

            foreach (var item in itemsControl.Items)
            {
                var container = itemsControl.ContainerFromItem(item);
                var elementVisual = ElementCompositionPreview.GetElementVisual((SelectorItem)container);
                elementVisual.ImplicitAnimations = elementImplicitAnimation;
            }
        }

        private static CompositionAnimationGroup CreateOffsetAnimation(Compositor compositor)
        {
            // Define Offset Animation for the Animation group
            Vector3KeyFrameAnimation offsetAnimation = compositor.CreateVector3KeyFrameAnimation();
            offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
            offsetAnimation.Duration = TimeSpan.FromSeconds(.2);

            // Define Animation Target for this animation to animate using definition. 
            offsetAnimation.Target = "Offset";

            //// Define Rotation Animation for Animation Group. 
            //ScalarKeyFrameAnimation rotationAnimation = compositor.CreateScalarKeyFrameAnimation();
            //rotationAnimation.InsertKeyFrame(.5f, 0.160f);
            //rotationAnimation.InsertKeyFrame(1f, 0f);
            //rotationAnimation.Duration = TimeSpan.FromSeconds(.4);

            //// Define Animation Target for this animation to animate using definition. 
            //rotationAnimation.Target = "RotationAngle";

            // Add Animations to Animation group. 
            CompositionAnimationGroup animationGroup = compositor.CreateAnimationGroup();
            animationGroup.Add(offsetAnimation);
            //animationGroup.Add(rotationAnimation);

            return animationGroup;
        }
    }
}

