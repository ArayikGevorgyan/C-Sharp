<Window x:Class="Autopropertys_in_class.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:Autopropertys_in_class"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" Background="#F08080" ResizeMode="NoResize">
    <Grid>
        <TextBox x:Name="OutputBox" HorizontalAlignment="Left" Height="414" Margin="10,0,0,0" VerticalAlignment="Center" Width="340" Text="" IsReadOnly="True" FontSize="18" TextChanged="OutputBox_TextChanged"/>
        <Button x:Name="Input_Button" Content="Input" HorizontalAlignment="Left" Height="31" Margin="410,103,0,0" VerticalAlignment="Top" Width="140" Click="Input_Button_Click" FontSize="18"/>
        <Button x:Name="Sort_Age_Button" Content="Sort by age" HorizontalAlignment="Left" Height="31" Margin="610,147,0,0" VerticalAlignment="Top" Width="140" Click="Sort_Age_Button_Click" FontSize="18"/>
        <Button x:Name="Sort_Name_Button" Content="Sort by name" HorizontalAlignment="Left" Height="31" Margin="410,193,0,0" VerticalAlignment="Top" Width="140" Click="Sort_Name_Button_Click" FontSize="18"/>
        <Button x:Name="Search_Age_Button" Content="Search by age" HorizontalAlignment="Left" Height="31" Margin="610,103,0,0" VerticalAlignment="Top" Width="140" Click="Search_Age_Button_Click" FontSize="18"/>
        <Button x:Name="Search_Name_Button" Content="Search by name" HorizontalAlignment="Left" Height="31" Margin="410,147,0,0" VerticalAlignment="Top" Width="140" Click="Search_Name_Button_Click" FontSize="18"/>
        <Button x:Name="Delete_ID_Button" Content="Delete ID" HorizontalAlignment="Left" Height="31" Margin="610,193,0,0" VerticalAlignment="Top" Width="140" Click="Delete_ID_Button_Click" FontSize="18"/>
        <TextBox x:Name="NameInputBox" HorizontalAlignment="Left" Height="31" Margin="489,53,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="170" FontSize="18"/>
        <TextBox x:Name="InstructionBox" HorizontalAlignment="Left" Height="166" Margin="410,258,0,0" VerticalAlignment="Top" Width="340" Text="1) Input name and age&#xA;2) Input age&#xA;3) Input name&#xA;4) Input age&#xA;5) Input name&#xA;6) Input ID" IsReadOnly="True" Background="#FA8072" FontSize="18"/>
        <TextBox x:Name="AgeInputBox" HorizontalAlignment="Left" Height="31" Margin="664,53,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="91" FontSize="18" TextChanged="AgeInputBox_TextChanged"/>
        <TextBox x:Name="IDInputBox" HorizontalAlignment="Left" Height="31" Margin="410,53,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Width="74" FontSize="18"/>
        <TextBlock HorizontalAlignment="Left" Height="32" Margin="410,16,0,0" TextWrapping="Wrap" Text="ID" VerticalAlignment="Top" Width="70" FontSize="20"/>
        <TextBlock HorizontalAlignment="Left" Height="32" Margin="489,16,0,0" TextWrapping="Wrap" Text="Name" VerticalAlignment="Top" Width="99" FontSize="20"/>
        <TextBlock HorizontalAlignment="Left" Height="32" Margin="664,16,0,0" TextWrapping="Wrap" Text="Age" VerticalAlignment="Top" Width="70" FontSize="20"/>
    </Grid>
</Window>


//---------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows;

namespace Autopropertys_in_class
{

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int ID { get; set; }


    }
    public partial class MainWindow : Window
    {
        static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }

        static int maxRecordCount = 17;
        int recordCount = 0;
        (string Name, int Age)[] Data = new (string Name, int Age)[maxRecordCount];
        (string Name, int Age)[] temp = new (string Name, int Age)[maxRecordCount];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PrintResult()
        {
            NameInputBox.Text = AgeInputBox.Text = IDInputBox.Text = "";
            OutputBox.Text = "";
            for (int i = 0; i < recordCount; i++)
            {
                OutputBox.Text += $"ID: {i}, Name: {Data[i].Name}, Age: {Data[i].Age}\n";
            }
        }

        private void Input_Button_Click(object sender, RoutedEventArgs e)
        {
            if (recordCount < maxRecordCount)
            {
                if (int.TryParse(AgeInputBox.Text, out int age))
                {
                    Data[recordCount].Name = NameInputBox.Text;
                    Data[recordCount].Age = age;
                    OutputBox.Text += $"ID: {recordCount}, Name: {Data[recordCount].Name}, Age: {Data[recordCount].Age}\n";
                    AgeInputBox.Text = NameInputBox.Text = "";
                    recordCount += 1;
                }
                else
                {
                    AgeInputBox.Text = "Invalid age";
                }

            }

            else
            {
                NameInputBox.Text = "No space left";
            }

        }

        private void Sort_Age_Button_Click(object sender, RoutedEventArgs e)
        {

            for (int z = 0; z < recordCount; z++)
                for (int i = 0; i < recordCount - 1; i++)
                {
                    if (Data[i].Age > Data[i + 1].Age)
                    {
                        temp[0] = Data[i];
                        Data[i] = Data[i + 1];
                        Data[i + 1] = temp[0];
                    }
                }

            PrintResult();

        }

        private void Sort_Name_Button_Click(object sender, RoutedEventArgs e)
        {

            for (int z = 0; z < recordCount; z++)
                for (int i = 0; i < recordCount - 1; i++)
                {
                    if (Data[i].Name.CompareTo(Data[i + 1].Name) > 0)
                    {
                        temp[0] = Data[i];
                        Data[i] = Data[i + 1];
                        Data[i + 1] = temp[0];
                    }
                }

            PrintResult();

        }

        private void Search_Age_Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AgeInputBox.Text, out int Age))
            {
                for (int i = 0; i < recordCount; i++)
                {
                    if (Data[i].Age == Age)
                    {
                        IDInputBox.Text = $"{i}";
                        NameInputBox.Text = $"{Data[i].Name}";
                        AgeInputBox.Text = $"{Data[i].Age}";
                    }
                }
            }
            else
            {
                AgeInputBox.Text = "Invalid";
            }

        }

        private void Search_Name_Button_Click(object sender, RoutedEventArgs e)
        {
            bool nameFound = false;
            Name = NameInputBox.Text;
            for (int i = 0; i < recordCount; i++)
            {
                if (Name == Data[i].Name)
                {
                    nameFound = true;
                    IDInputBox.Text = $"{i}";
                    NameInputBox.Text = $"{Data[i].Name}";
                    AgeInputBox.Text = $"{Data[i].Age}";
                }
            }
            if (!nameFound)
            {
                NameInputBox.Text = "No person";
            }

        }

        private void Delete_ID_Button_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(IDInputBox.Text, out int ID) && ID < recordCount)
            {
                for (int i = ID; i < recordCount - 1; i++)
                {
                    temp[0] = Data[i];
                    Data[i] = Data[i + 1];
                    Data[i + 1] = temp[0];
                }

                --recordCount;
                PrintResult();
            }
            else
            {
                IDInputBox.Text = "Invalid";
            }
        }

        private void OutputBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void AgeInputBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
