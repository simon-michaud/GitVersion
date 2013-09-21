﻿using System;
using GitFlowVersion;

public static class VersionInformationalConverter
{
    public static string ToLongString(this VersionAndBranch versionInformation)
    {
        var version = versionInformation.Version;
        var versionPrefix = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Patch);

        if (versionInformation.BranchType == BranchType.Feature)
        {
            var shortSha = versionInformation.Sha.Substring(0, 8);
            return string.Format("{0}-unstable.feature-{1} Branch:'{2}' Sha:'{3}'", versionPrefix, shortSha, versionInformation.BranchName, versionInformation.Sha);
        }

        if (versionInformation.BranchType == BranchType.PullRequest)
        {
            return string.Format("{0}-unstable.pull-request-{1} Branch:'{2}' Sha:'{3}'", versionPrefix, version.PreReleaseNumber, versionInformation.BranchName, versionInformation.Sha);
        }

        if (versionInformation.BranchType == BranchType.Develop)
        {
            return string.Format("{0}-unstable{1} Branch:'{2}' Sha:'{3}'", versionPrefix, version.PreReleaseNumber, versionInformation.BranchName, versionInformation.Sha);
        }

        if (versionInformation.BranchType == BranchType.Release)
        {
            if (version.Stability == Stability.ReleaseCandidate)
            {
                return string.Format("{0}-rc{1} Branch:'{2}' Sha:'{3}'", versionPrefix, version.PreReleaseNumber, versionInformation.BranchName, versionInformation.Sha);
            }
            return string.Format("{0}-beta{1} Branch:'{2}' Sha:'{3}'", versionPrefix, version.PreReleaseNumber, versionInformation.BranchName, versionInformation.Sha);
        }

        if (versionInformation.BranchType == BranchType.Hotfix)
        {
            return string.Format("{0}-beta{1} Branch:'{2}' Sha:'{3}'", versionPrefix, version.PreReleaseNumber, versionInformation.BranchName, versionInformation.Sha);
        }

        if (versionInformation.BranchType == BranchType.Master)
        {
            return string.Format("{0} Sha:'{1}'", versionPrefix, versionInformation.Sha);
        }

        throw new Exception(string.Format("Invalid branch type '{0}'.", versionInformation.BranchType));
    }
    public static string ToShortString(this VersionAndBranch versionInformation)
    {
        var version = versionInformation.Version;
        var versionPrefix = string.Format("{0}.{1}.{2}", version.Major, version.Minor, version.Patch);

        if (versionInformation.BranchType == BranchType.Feature)
        {
            var shortSha = versionInformation.Sha.Substring(0, 8);
            return string.Format("{0}-unstable.feature-{1}", versionPrefix, shortSha);
        }

        if (versionInformation.BranchType == BranchType.PullRequest)
        {
            return string.Format("{0}-unstable.pull-request-{1}", versionPrefix, version.PreReleaseNumber);
        }

        if (versionInformation.BranchType == BranchType.Develop)
        {
            return string.Format("{0}-unstable{1}", versionPrefix, version.PreReleaseNumber);
        }

        if (versionInformation.BranchType == BranchType.Release)
        {
            if (version.Stability == Stability.ReleaseCandidate)
            {
                return string.Format("{0}-rc{1}", versionPrefix, version.PreReleaseNumber);
            }
            return string.Format("{0}-beta{1}", versionPrefix, version.PreReleaseNumber);
        }

        if (versionInformation.BranchType == BranchType.Hotfix)
        {
            return string.Format("{0}-beta{1}", versionPrefix, version.PreReleaseNumber);
        }

        if (versionInformation.BranchType == BranchType.Master)
        {
            return versionPrefix;
        }

        throw new Exception(string.Format("Invalid branch type '{0}'.", versionInformation.BranchType));
    }
}