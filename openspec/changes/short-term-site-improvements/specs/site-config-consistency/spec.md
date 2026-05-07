## ADDED Requirements

### Requirement: Hugo version policy is explicit
The project SHALL document the recommended Hugo version and SHALL ensure the GitHub Actions build version is either aligned with that recommendation or explicitly documented as the supported CI version.

#### Scenario: Maintainer checks setup instructions
- **WHEN** a maintainer reads the project README
- **THEN** the README states the recommended Hugo version or supported version range

#### Scenario: CI version is reviewed
- **WHEN** a maintainer inspects `.github/workflows/hugo.yaml`
- **THEN** the configured Hugo version is consistent with the documented version policy

### Requirement: Pagination configuration is self-consistent
The project SHALL keep the `hugo.toml` pagination value and its nearby documentation or comments consistent.

#### Scenario: Pagination setting is inspected
- **WHEN** a maintainer reads the `pagerSize` setting in `hugo.toml`
- **THEN** the comment or documentation describes the same number of posts per page

### Requirement: Internal navigation is baseURL-aware
The site SHALL generate primary internal navigation links without hardcoding the `/CplusHouse` deployment prefix in layout templates.

#### Scenario: Header links are rendered locally
- **WHEN** the site is served with `hugo server -F`
- **THEN** header links for home, blog, and projects resolve correctly in the local environment

#### Scenario: Header links are rendered for GitHub Pages
- **WHEN** the site is built with the configured GitHub Pages baseURL
- **THEN** header links for home, blog, and projects include the correct deployed base path

### Requirement: Static image path strategy is defined
The project SHALL define a consistent strategy for Markdown image paths that reference static images, and SHALL avoid introducing known broken image references.

#### Scenario: Existing hardcoded image paths are reviewed
- **WHEN** maintainers inspect Markdown files containing `/CplusHouse/images/`
- **THEN** the chosen path strategy is documented or applied consistently

#### Scenario: Site build includes image references
- **WHEN** the site is built for verification
- **THEN** representative article image references remain valid for the supported deployment target

### Requirement: README reflects repository reality
The README SHALL describe the current project structure, local execution commands, deployment workflow, and content categories accurately.

#### Scenario: README project structure is compared to files
- **WHEN** a maintainer compares README structure notes with the repository
- **THEN** the described directories exist or are clearly marked as planned or optional

#### Scenario: Local setup is followed
- **WHEN** a maintainer follows README local setup instructions
- **THEN** the documented command uses `hugo server -F`

### Requirement: Project fallback assets are valid or clearly marked
Project fallback configuration SHALL NOT silently reference missing images as if they are production-ready assets.

#### Scenario: Fallback projects are inspected
- **WHEN** a maintainer reviews `params.projects` in `hugo.toml`
- **THEN** image references either point to existing assets or are clearly marked as examples or placeholders

