using System;

namespace AlphaTrade
{
    public class Action
    {
        public enum Types
        {
            WINDOW_POSITIONS,
            WINDOW_ORDERS,
            WINDOW_CHART,
            WINDOW_ORDER_BOOK,

            CREATE_ORDER,
            MODIFY_ORDER,
            CANCEL_ORDER,
            CANCEL_ALL_ORDERS,
            UPDATE_ORDERS,

            CLOSE_POSITION,
            CLOSE_ALL_POSITIONS,
            UPDATE_POSITIONS
        }

        public Types Type;
        public object Args;
        public object Result;

        public Action(Types type, object args = null)
        {
            this.Type = type;
            this.Args = args;
        }
    }
}
