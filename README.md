FindTextByRegexp
================

Primitive command line tool for searching through text file for Regular expression matches. Results were saved in separate text file. They are quoted and comma separated

The command line format is following:

FindTextByRegexp.exe &lt;path_to_source_txt_file&gt; &lt;path_to_txt_file_with_regexp_pattern&gt; &lt;path_to_result_file&gt;

There are 3 required parameters. First 2 should be existing files the third one will be created.

<b>WARNING</b>: file by <path_to_result_files> will be overwritten during programm execution in case it exests.

Why this stuff has been created?
Tried to search txt file by regexp (Notepad++ was able to help me with that) but couldn't find any way how to save found matches to the separate file.
