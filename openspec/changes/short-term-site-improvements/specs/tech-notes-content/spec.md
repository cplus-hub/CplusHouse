## ADDED Requirements

### Requirement: Technical notes section exists
The project SHALL provide a dedicated technical notes section under `content/blog/tech/` with a Hugo `_index.md` section file.

#### Scenario: Technical notes section is inspected
- **WHEN** a maintainer inspects `content/blog/tech/`
- **THEN** `_index.md` exists with the title `技術筆記`

### Requirement: Technical notes front matter is documented
The project SHALL document the expected front matter fields for technical note articles.

#### Scenario: Author reads technical note instructions
- **WHEN** an author reads the README instructions for adding technical notes
- **THEN** the instructions include `title`, `date`, `summary`, and `tags` fields

### Requirement: Technical notes participate in blog behavior
Technical note articles SHALL be treated as blog regular pages and participate in existing blog list, search index, and tag pages.

#### Scenario: Technical note article is added
- **WHEN** an author adds a non-draft Markdown article under `content/blog/tech/`
- **THEN** Hugo includes it in the blog regular pages

#### Scenario: Technical note article has tags
- **WHEN** a technical note article includes tags in front matter
- **THEN** those tags appear through the existing tag taxonomy behavior

#### Scenario: Search index is generated
- **WHEN** Hugo generates `index.json`
- **THEN** eligible technical note articles are included in the search index

### Requirement: No placeholder article is required
The technical notes section SHALL NOT require a fake or placeholder article for the site to build successfully.

#### Scenario: Section contains no technical note articles
- **WHEN** `content/blog/tech/` contains only `_index.md`
- **THEN** the Hugo build still succeeds

