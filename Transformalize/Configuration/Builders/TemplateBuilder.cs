namespace Transformalize.Configuration.Builders {
    public class TemplateBuilder {
        private readonly ProcessBuilder _processBuilder;
        private readonly TemplateConfigurationElement _template;

        public TemplateBuilder(ProcessBuilder processBuilder, TemplateConfigurationElement template) {
            _processBuilder = processBuilder;
            _template = template;
        }

        public TemplateBuilder File(string name) {
            _template.File = name;
            return this;
        }

        public TemplateBuilder Cache(bool cache) {
            _template.Cache = cache;
            return this;
        }

        public TemplateBuilder ContentType(string contentType) {
            _template.ContentType = contentType;
            return this;
        }

        public TemplateBuilder Template(string name) {
            return _processBuilder.Template(name);
        }

        public EntityBuilder Entity(string name) {
            return _processBuilder.Entity(name);
        }

        public ActionBuilder Action(string action) {
            var a = new ActionConfigurationElement() { Action = action };
            _template.Actions.Add(a);
            return new ActionBuilder(this, a);
        }

        public SearchTypeBuilder SearchType(string name) {
            return _processBuilder.SearchType(name);
        }

        public MapBuilder Map(string name) {
            return _processBuilder.Map(name);
        }

        public ProcessBuilder TemplatePath(string path) {
            return _processBuilder.TemplatePath(path);
        }

        public ProcessBuilder ScriptPath(string path) {
            return _processBuilder.ScriptPath(path);
        }
    }
}