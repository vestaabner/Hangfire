// This file is part of Hangfire.
// Copyright © 2013-2014 Sergey Odinokov.
// 
// Hangfire is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as 
// published by the Free Software Foundation, either version 3 
// of the License, or any later version.
// 
// Hangfire is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public 
// License along with Hangfire. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace Hangfire.Dashboard
{
    internal class CommandDispatcher : IRequestDispatcher
    {
        private readonly Func<RequestDispatcherContext, bool> _command;

        public CommandDispatcher(Func<RequestDispatcherContext, bool> command)
        {
            _command = command;
        }

        public Task Dispatch(RequestDispatcherContext context)
        {
            var owinContext = new OwinContext(context.OwinEnvironment);

            if (owinContext.Request.Method != WebRequestMethods.Http.Post)
            {
                owinContext.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                return Task.FromResult(false);
            }

            if (_command(context))
            {
                owinContext.Response.StatusCode = (int)HttpStatusCode.NoContent;
            }
            else
            {
                owinContext.Response.StatusCode = 422;
            }

            return Task.FromResult(true);
        }
    }
}
