using System.Dynamic;
using System;

namespace CoolSharp.Dynamic.PrivateAccess
{
    public class PrivateAccessor<T> : DynamicObject where T : class
    {
private readonly T @object = default;

            public PrivateAccessor(T @object)
            {
                this.@object = @object;
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                string name = binder.Name;
                var field = typeof(T).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
                {
                    result = field.GetValue(@object);
                    return true;
                }
                else
                {
                    try
                    {
                        result = new Property<object>(@object, name).Value;
                        return true;
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                string name = binder.Name;
                var field = typeof(T).GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
                if (field != null)
                {
                    field.SetValue(@object, value);
                    return true;
                }
                else
                {
                    try
                    {
                        new Property<object>(@object, name).Value = value;
                        return true;
                    }
                    catch
                    {
                        throw new Exception();
                    }
                }
            }
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                var callback = binder.Name;
                var method = @object.GetType().GetMethod(callback, BindingFlags.NonPublic | BindingFlags.Instance);
                if (method == null)
                {
                    throw new NullReferenceException();
                }
                try
                {
                    result = method?.Invoke(@object, args);
                    return true;
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                    {
                       throw e.InnerException;
                    }
                    throw e;
                }
            }
    }
}