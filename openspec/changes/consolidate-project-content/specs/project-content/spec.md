## ADDED Requirements

### Requirement: Project content is maintained in Markdown
The project SHALL use `content/projects` as the primary source for production project entries.

#### Scenario: Project content exists
- **WHEN** a project is intended to appear as production content
- **THEN** it is represented by a Markdown file under `content/projects`

### Requirement: Project front matter includes display fields
Project Markdown files SHALL support the front matter fields required by the project list and detail templates.

#### Scenario: Project front matter is inspected
- **WHEN** a maintainer opens a project Markdown file
- **THEN** the file includes `title`, `date`, `description`, `image`, `dev_time`, `tech_stack`, and `features` fields when applicable

### Requirement: Home project section uses content projects
The home page project section SHALL use `content/projects` as its primary data source.

#### Scenario: Content projects are present
- **WHEN** at least one regular page exists under `content/projects`
- **THEN** the home page project section displays projects from `content/projects`

### Requirement: Project list page displays content projects
The `/projects/` page SHALL list project pages maintained under `content/projects`.

#### Scenario: Projects page is rendered
- **WHEN** Hugo renders the projects list page
- **THEN** the page displays project cards for eligible project content pages

### Requirement: Project detail page displays full project data
Project detail pages SHALL display Markdown content and supported project front matter fields.

#### Scenario: Project detail page is rendered
- **WHEN** a user opens a project detail page
- **THEN** the page displays the project title, featured image, development time, tech stack, Markdown content, and feature list when provided

### Requirement: Config fallback is not treated as production content
The `params.projects` configuration SHALL either be removed or clearly documented as fallback/example data rather than the primary project source.

#### Scenario: Maintainer inspects project settings
- **WHEN** a maintainer reads `hugo.toml` and README
- **THEN** it is clear whether `params.projects` is removed or only fallback/example data

### Requirement: Project content workflow is documented
The README SHALL document how to add a project page and which front matter fields are expected.

#### Scenario: Author reads project documentation
- **WHEN** an author reads the README project creation section
- **THEN** the README explains where to place project Markdown files and which front matter fields to use
