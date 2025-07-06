using System;
using System.Windows.Input;

// 定义一个实现了 ICommand 接口的 RelayCommand 类
public class RelayCommand : ICommand
{
    // 当命令是否可执行状态发生变化时触发的事件
    public event EventHandler? CanExecuteChanged;

    // 执行命令的委托（执行具体的动作）
    private Action<object> _Excute { get; set; }

    // 判断命令是否可以执行的委托（返回 true 表示可以执行）
    private Predicate<object> _CanExcute { get; set; }

    // 构造函数，传入执行方法和可执行判断方法
    public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
    {
        _Excute = ExcuteMethod;
        _CanExcute = CanExcuteMethod;
    }

    // 判断命令是否可以执行（由外部传入的 _CanExcute 决定）
    public bool CanExecute(object? parameter)
    {
        return _CanExcute(parameter);
    }

    // 执行命令的具体逻辑（由外部传入的 _Excute 决定）
    public void Execute(object? parameter)
    {
        _Excute(parameter);
    }
}
