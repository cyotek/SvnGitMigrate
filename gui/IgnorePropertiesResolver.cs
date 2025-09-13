// Code Maze Guides
// https://github.com/CodeMazeBlog/CodeMazeGuides/blob/a022c0ee66cb52fe840381bb4f2ed0f95c81a5aa/json-csharp/ExcludePropertyJsonInCSharp/ExcludePropertyJsonInCSharp/Resolvers/IgnorePropertiesResolver.cs

// Copyright (c) 2021 Code Maze

// This work is licensed under the MIT License.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace Cyotek.SvnMigrate.Client
{
  internal class IgnorePropertiesResolver : DefaultContractResolver
  {
    #region Private Fields

    private readonly HashSet<string> _ignoreProps;

    #endregion Private Fields

    #region Public Constructors

    public IgnorePropertiesResolver(params string[] propNamesToIgnore)
    {
      _ignoreProps = new HashSet<string>(propNamesToIgnore);
    }

    #endregion Public Constructors

    #region Protected Methods

    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
      JsonProperty property = base.CreateProperty(member, memberSerialization);
      
      if (_ignoreProps.Contains(property.PropertyName))
      {
        property.ShouldSerialize = _ => false;
      }
      
      return property;
    }

    #endregion Protected Methods
  }
}