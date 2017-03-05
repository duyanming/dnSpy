﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.ObjectModel;
using dnSpy.Contracts.Debugger;
using dnSpy.Contracts.Debugger.Engine;

namespace dnSpy.Debugger.Impl {
	sealed class DbgEngineThreadImpl : DbgEngineThread {
		public override DbgThread Thread => thread;
		readonly DbgThreadImpl thread;

		public DbgEngineThreadImpl(DbgThreadImpl thread) => this.thread = thread ?? throw new ArgumentNullException(nameof(thread));

		public override void Remove() => thread.Remove();

		public override void Update(UpdateOptions options, string kind, int id, int? managedId, string name, ReadOnlyCollection<DbgStateInfo> state) {
			if (thread.IsClosed)
				return;
			if ((options & UpdateOptions.Kind) != 0)
				thread.UpdateKind_DbgThread(kind);
			if ((options & UpdateOptions.Id) != 0)
				thread.UpdateId_DbgThread(id);
			if ((options & UpdateOptions.ManagedId) != 0)
				thread.UpdateManagedId_DbgThread(managedId);
			if ((options & UpdateOptions.Name) != 0)
				thread.UpdateName_DbgThread(name);
			if ((options & UpdateOptions.State) != 0)
				thread.UpdateState_DbgThread(state);
		}
	}
}
