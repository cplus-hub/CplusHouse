## ADDED Requirements

### Requirement: Search results highlight matching terms
The site search SHALL highlight the user query wherever it appears in displayed result titles, summaries, and tags.

#### Scenario: Chinese query matches a result
- **WHEN** a user searches for a Chinese keyword that appears in a result title or summary
- **THEN** the matching text is visibly highlighted in the search result

#### Scenario: Tag query matches a result
- **WHEN** a user searches for a keyword that appears in a result tag
- **THEN** the matching tag text is visibly highlighted

### Requirement: Search summaries prioritize match context
The site search SHALL display summary text from near the first content match when the query appears in article content.

#### Scenario: Query appears in article content
- **WHEN** a user searches for a keyword that appears in an article body
- **THEN** the result summary shows text around the matching keyword

#### Scenario: Query does not appear in article content
- **WHEN** a user searches for a keyword that matches only the title or tags
- **THEN** the result summary falls back to the article summary

### Requirement: Search input is normalized and regex-safe
The site search SHALL trim user input, perform case-insensitive matching, and handle special characters without throwing regular expression errors.

#### Scenario: Query contains surrounding whitespace
- **WHEN** a user enters a query with leading or trailing spaces
- **THEN** the search behaves as if the spaces were not entered

#### Scenario: Query contains regex characters
- **WHEN** a user searches for text containing characters such as `.` or `+`
- **THEN** the search does not throw an error and treats the characters as literal text

### Requirement: Search output is safely rendered
The site search SHALL escape article-derived text and user-derived text before inserting highlighted HTML into the page.

#### Scenario: Article text contains HTML-like characters
- **WHEN** a search result includes text containing `<` or `>`
- **THEN** the text is displayed as text and does not become executable or structural HTML

### Requirement: Search visual states remain usable
Search result highlighting SHALL be readable in both light mode and dark mode, and existing empty-query and no-result states SHALL remain functional.

#### Scenario: User clears the search query
- **WHEN** a user clears the search input
- **THEN** the default article list is shown and the search results are hidden

#### Scenario: Query has no matches
- **WHEN** a user enters a query with no matching posts
- **THEN** the site displays the no-results message

#### Scenario: Dark mode is active
- **WHEN** dark mode is active and a search result contains a highlight
- **THEN** the highlighted text remains visually distinguishable

