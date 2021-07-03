# Cyotek Svn2Git Migration Utility

This repository hosts a naive utility for creating a Git
repository from an existing SVN folder, making it useful for
breaking a mono SVN Repository into smaller Git repositories.

> This tool is a work in progress that I did for breaking up my
> own repository. It may not work for all cases, for example if
> root folders were renamed or moved.
>
> It has only received limited testing and is provided AS-IS

## How does it work?

In the simplest fashion possible - you give it a location in
SVN, it will enumerate the revisions in that location and will
check each one out in reverse order and check them into a Git
repository with the appropriate date, author and log
information. That is it, nothing fancy.

The code is a little messy, I did start to break it up into more
reusable and testable components but this work is ongoing.

## Selecting Revisions

![Selecting revisions][step1]

* Enter the URL of the _remote_ SVN path you want to migrate.
  This will then list all revisions associated with that
  location
* Select the revisions you wish to migrate

## Mapping Authors

![Entering author mappings][step2]

SVN uses a simple name for attribution, but Git requires a name
and email address pair. The Author Mapping tab will list any
detected authors for the selected revisions, for each author
ensure there is a name and email address in the pattern
`svn_name = git_name <git_email>`.

## Inclusions and Exclusions

![Defining exclusions][step3]

If there are files you want to exclude from the new repository
(for example a scratch program full of credentials that should
never have been committed to begin with!), you can configure a
set of include or exclude patterns to manage which files will be
copied from each SVN checkout to the Git repository.

Enter glob patterns in either the inclusion or exclusion fields,
or both. Files will only be included if they are both included
and not excluded. If the includes field is blank, then all files
are included. If the excludes field is blank, then no files will
be excluded.

For example, if you had a folder named `/src/Scratch` in your
repository which you didn't want migrated, then you could enter
the glob `/**/Scratch` to the exclusion list.

Don't use backslashes in globs, the migration tool will
automatically handle conversion from Windows paths.

## Selecting the Git Repository

![Selecting the Git Repository][step4]

Enter the local folder where the Git repository will be located.

If you are creating a new repository, ensure the folder is empty
the _Use existing repository_ option is unchecked.

If you want to append the commits to an existing repository,
ensure the folder points to the existing repository and check
the _Use existing repository_ option. This can be useful if you
are having to build a Git repository from multiple sources, e.g.
if a root folder was renamed or moved.

## Migrate

![Selecting the Git Repository][step5]

Click the Migrate button to start the process. For each selected
revision, this tool will check that out, sync the contents with
the Git repository, then perform a commit.

[step1]: res/step1.png
[step2]: res/step2.png
[step3]: res/step3.png
[step4]: res/step4.png
[step5]: res/step5.png
