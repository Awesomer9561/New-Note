using Android.Content;
using Android.Graphics.Drawables;
using New_Note.Droid.Custom_Renderer;
using New_Note.Misc;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorCustomRenderer))]

namespace New_Note.Droid.Custom_Renderer
{
    class MyEditorCustomRenderer:EditorRenderer
    {
        public MyEditorCustomRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Android.Graphics.Color.Transparent);

                Control.SetBackground(gradientDrawable);
            }
        }
    }
}