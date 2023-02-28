# Cyotek Svn2Git Migration Utility

## Change Log

### 1.4

#### Added

* Added simple preview

#### Fixed

* Includes and excludes weren't correctly processing, meaning entire commits
  could be incorrectly excluded

### 1.3

#### Changed

* Glob pattern matching no longer applies to folder names,
  preventing issues where files were checked out of SVN but not
  synced into the Git repository

### 1.2

#### Changed

* Glob pattern matching now applies to SVN revisions, preventing
  needless checkouts if none of the files in the revision will
  be processed

#### Fixed

* Migration log would sometimes list the same SVN revision
  multiple times even though each revision is only processed
  once

### 1.1

#### Added

* Added the ability to specify globs for including or excluding
  files from being migrated to the new repository  

### 1.0

* Initial release
