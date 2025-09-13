# Cyotek Svn2Git Migration Utility

This repository hosts a naive utility for creating a Git
repository from an existing SVN tree, making it useful for
breaking a mono SVN Repository into smaller Git repositories.

> This tool is a work in progress that I did for breaking up my
> own repository. It may not work for all cases, for example if
> root folders were renamed or moved.
>
> It has only received limited testing and is provided AS-IS.

## How does it work?

In the simplest fashion possible - you give it a location in
SVN, it will enumerate the revisions in that location (and its
sub folders) and will check each one out in reverse order and
commit them into a Git repository with the appropriate date,
author and log information. That is it, nothing fancy.

You are able to specify glob patterns for file includes and
excludes, which can be useful if you want to exclude files
originally accidentally committed, or that you simply don't want
in the new repository.

The code is a little messy, I did start to break it up into more
reusable and testable components but this work is ongoing.

## Selecting Revisions

![Selecting revisions][step1]

* Enter the URL of the _remote_ SVN path you want to migrate.
  This will then list all revisions associated with that
  location.
* Optionally, enter the base path for matching files in the
  commit, or leave blank to use the auto detected value.
* Select the revisions you wish to migrate. Revisions that are
  greyed out have no files matching the base path expression.

> Context-click the list view for **Select All**, **Select
> None** and **Invert** options.

### More on the Base Path

The migration utility can't tell what files are "affected", and
so makes a best guess based on the auto detected base path. This
may not always be appropriate. For example, the below screenshot
shows some of the files from a very early commit to
`/cyotek/trunk/cyotek/source/Libraries/Cyotek.Web.Crawler`, but
not that the path starts with `/trunk/checkout` not
`/trunk/cyotek` and so these files are ignored.

![An example of an old commit with different paths][basepath1]

> To view the files in a revision, context-click a revision and
> choose **File List...** from the menu.

Consider a new commit where the paths do match.

![An example of a commit with correct paths][basepath2]

The migration utility allows the base path to be specified, and
to handle scenarios such as the above it allows glob expressions
to be used. For example, all files from the two lists above
could be captured with either of the following patterns.

* `/**/Libraries/Cyotek.Web.Crawler/**/*`
* `/trunk/checkout/source/Libraries/Cyotek.Web.Crawler/|/trunk/cyotek/source/Libraries/Cyotek.Web.Crawler/`

In the case of the latter pattern, the migration utility will
automatically add `**/*` to patterns that don't include any glob
characters.

The revisions list "greys out" any revisions where no files were
matched, providing a visual clue that something is amiss.

![A mix of revisions][basepath3]

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
the glob `/**/Scratch/**/*` to the exclusion list.

> Don't use backslashes in globs, the migration tool will
> automatically handle conversion from Windows paths.

## Selecting the Git Repository

![Selecting the Git Repository][step4]

Enter the local folder where the Git repository will be located.

If you are creating a new repository, ensure the folder is empty
the **Use existing repository** option is unchecked.

If you want to append the commits to an existing repository,
ensure the folder points to the existing repository and check
the **Use existing repository option**. This can be useful if
you are having to build a Git repository from multiple sources,
e.g. if a root folder was renamed or moved.

You can also customise the template used to generate commit
messages. Templates are in [Scriban][scriban] format, with the
following variables available:

* `log` - the SVN log message
* `author` - the SVN author
* `revision` - the revision ID
* `timestamp` - the commit timestamp
* `repository_uri` - the URI of the SVN commit

## Preview

![Generating an optional preview][step5]

Click the **Preview** button to display a simplified preview.
This will scan the revisions and test changed files against
inclusion and exclusion patterns, then print a list of all
matched files. This can be very useful to make sure you have
your patterns set right, and also to review file lists in case
you see something that needs adding to the exclusions.

## Migrate

![Performing a migration][step6]

Click the **Migrate** button to start the process. For each
selected revision, this tool will check that out, sync the
contents with the Git repository (honoring include/exclude
rules), then perform a commit.

This may take some time to perform.

## Profiles

To save the current migration settings (with the exception of
revision selections) to a JSON file, open the **File** menu and
choose **Save Profile As**.

To load previously saved settings, open the **File** menu and
choose **Open Profile**.

[step1]: res/step1.png
[step2]: res/step2.png
[step3]: res/step3.png
[step4]: res/step4.png
[step5]: res/step5.png
[step6]: res/step6.png
[basepath1]: res/basepath1.png
[basepath2]: res/basepath2.png
[basepath3]: res/basepath3.png
[scriban]: https://github.com/scriban/scriban?tab=readme-ov-file#documentation
