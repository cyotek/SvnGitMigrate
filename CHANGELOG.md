# Cyotek Svn2Git Migration Utility

## Change Log

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
