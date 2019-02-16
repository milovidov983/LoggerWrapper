# LoggerWrapper

## Introduction

What prompted me to write this wrapper over the Nlog and Rollbar?
Everyone knows that in the Nlog you can connect various logging systems as a target, including Rollbar. 
However, when using a rollbar as a target for a Nlog, when logging, the Nlog behaves in the same way: it waits until the Rollbar operation completes, and this can be quite long. Therefore, I decide to write such a class where we will write logs to the console using Nlog and to Rollbar without waiting for an answer.

## Purpose

1) Be independent of the logging system.
2) Write log to The Rollbar asynchronously without waiting for an answer.

## Remarks

All settings of The Nlog and Rollbar are left to your discretion.
How Nlog and Rollbar are initialized you can see in the implementation file https://github.com/milovidov983/LoggerWrapper/blob/master/LoggerWrapper/LoggerImpl.cs
