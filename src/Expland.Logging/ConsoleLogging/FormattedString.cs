namespace Expland.Logging.ConsoleLogging;

public class FormattedString {
    public record Fragment {
        public ConsoleColor ForegroundColor { get; }
        public ConsoleColor BackgroundColor { get; }
        public string Text { get; }

        public Fragment(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string text) {
            this.ForegroundColor = foregroundColor;
            this.BackgroundColor = backgroundColor;
            this.Text = text;
        }
    }

    public List<Fragment> Fragments;

    public FormattedString() {
        this.Fragments = new List<Fragment>();
    }
}