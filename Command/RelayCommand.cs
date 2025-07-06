using System;
using System.Windows.Input;

// ����һ��ʵ���� ICommand �ӿڵ� RelayCommand ��
public class RelayCommand : ICommand
{
    // �������Ƿ��ִ��״̬�����仯ʱ�������¼�
    public event EventHandler? CanExecuteChanged;

    // ִ�������ί�У�ִ�о���Ķ�����
    private Action<object> _Excute { get; set; }

    // �ж������Ƿ����ִ�е�ί�У����� true ��ʾ����ִ�У�
    private Predicate<object> _CanExcute { get; set; }

    // ���캯��������ִ�з����Ϳ�ִ���жϷ���
    public RelayCommand(Action<object> ExcuteMethod, Predicate<object> CanExcuteMethod)
    {
        _Excute = ExcuteMethod;
        _CanExcute = CanExcuteMethod;
    }

    // �ж������Ƿ����ִ�У����ⲿ����� _CanExcute ������
    public bool CanExecute(object? parameter)
    {
        return _CanExcute(parameter);
    }

    // ִ������ľ����߼������ⲿ����� _Excute ������
    public void Execute(object? parameter)
    {
        _Excute(parameter);
    }
}
