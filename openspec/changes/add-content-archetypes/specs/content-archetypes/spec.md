## ADDED Requirements

### Requirement: Blog archetype exists
The project SHALL provide an archetype for general blog articles at `archetypes/blog.md`.

#### Scenario: General blog archetype is used
- **WHEN** an author runs `hugo new content blog/example.md -k blog`
- **THEN** Hugo creates a Markdown file with `title`, `date`, `author`, `summary`, and `tags` front matter fields

### Requirement: Diary archetype exists
The project SHALL provide an archetype for diary entries at `archetypes/diary.md`.

#### Scenario: Diary archetype is used
- **WHEN** an author runs `hugo new content blog/diary/2026/05/day20260507.md -k diary`
- **THEN** Hugo creates a Markdown file with `title`, `date`, `author`, `tags`, and `tag_notes` front matter fields

### Requirement: Tech archetype exists
The project SHALL provide an archetype for technical notes at `archetypes/tech.md`.

#### Scenario: Tech archetype is used
- **WHEN** an author runs `hugo new content blog/tech/my-note.md -k tech`
- **THEN** Hugo creates a Markdown file with `title`, `date`, `author`, `summary`, and `tags` front matter fields

### Requirement: Project archetype exists
The project SHALL provide an archetype for project pages at `archetypes/projects.md`.

#### Scenario: Project archetype is used
- **WHEN** an author runs `hugo new content projects/my-project.md -k projects`
- **THEN** Hugo creates a Markdown file with `title`, `date`, `description`, `image`, `dev_time`, `tech_stack`, and `features` front matter fields

### Requirement: Archetype usage is documented
The README SHALL document how to create blog, diary, tech, and project content using Hugo archetypes.

#### Scenario: Author reads content creation docs
- **WHEN** an author reads the README content creation sections
- **THEN** the README includes `hugo new content ... -k <kind>` commands for the supported content types

### Requirement: Archetype tests leave no content artifacts
Archetype verification SHALL NOT leave temporary test content in the repository.

#### Scenario: Archetype verification completes
- **WHEN** archetype generation has been tested
- **THEN** temporary test Markdown files are removed before the change is complete
