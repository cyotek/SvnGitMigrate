using System.IO;

// Cyotek Svn2Git Migration Utility

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.SvnMigrate.Client
{
  internal static class FileCompare
  {
    #region Private Fields

    private const int _bufferSize = 4096;

    #endregion Private Fields

    #region Public Methods

    public static bool AreSame(string x, string y)
    {
      using (Stream lhs = File.OpenRead(x))
      using (Stream rhs = File.OpenRead(y))
        return AreSame(lhs, rhs);
    }

    #endregion Public Methods

    #region Private Methods

    private static bool AreSame(Stream x, Stream y)
    {
      bool result;

      if (x.Length != y.Length)
      {
        result = false;
      }
      else
      {
        byte[] buffer1;
        byte[] buffer2;

        buffer1 = new byte[_bufferSize];
        buffer2 = new byte[_bufferSize];

        result = true;

        do
        {
          int r1;
          int r2;

          r1 = x.Read(buffer1, 0, _bufferSize);
          r2 = y.Read(buffer2, 0, _bufferSize);

          if (r1 == r2)
          {
            if (r1 == 0)
            {
              break;// done
            }
            else
            {
              for (int i = 0; i < r1; i++)
              {
                if (buffer1[i] != buffer2[i])
                {
                  result = false;
                  break;
                }
              }
            }
          }
          else
          {
            result = false;
          }
        } while (result);
      }

      return result;
    }

    #endregion Private Methods
  }
}