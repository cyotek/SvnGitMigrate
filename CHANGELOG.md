# Cyotek Svn2Git Migration Utility

## Change Log

### 1.6

#### Added

* Added Open Profile and Save Profile As commands, for quickly
  switching between migration settings.

### 1.5

#### Added

* Add new Base Path option, allowing the base path used to match
  change sets to be configured, in case the auto detection is
  invalid. Can also support glob patterns.
* Added new Commit Message Template option, allowing the git
  commit messages to be customised to include details such as
  revision ID or branch URL.

#### Changed

* The Git Repository Path is now a MRU.
* Revisions that won't result in a commit are now greyed out.
  Note that this only works from the initial base path, _not_
  custom includes excludes defined at a later step.
* File names in log messages are no longer trimmed.
* Log messages are now displayed in a separate tab.
* Updated packages to latest stable version.
* A log entry is now written if the preview doesn't find any
  results (e.g. bad include/excludes).

#### Fixed

* Auto detection of base path didn't work correctly via the SVN
  protocol (speculation, it could just be that it is nothing to
  do with the protocol and more the server setup!).
* Leading and trailing whitespace removed from SVN commit
  messages.
* When generating a preview, validation checks on the output
  folder are no longer performed.
* Cancelling an operation could cause another crash attempting
  to read the result.
* Minor, probably unnoticeable, performance tweaks.

### 1.4

#### Added

* Added simple preview

#### Fixed

* Includes and excludes weren't correctly processing, meaning
  entire commits could be incorrectly excluded

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
