﻿using DmgRolls.Helpers;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

/*
 * As I understand it, this code-behind basically functions as the controller?
 * Well, I'll use it as one, for what it's worth.
 */

namespace DmgRolls
{
    public partial class MainWindow : Window
    {
        public List<DiceRow> diceRows = new List<DiceRow>();

        public MainWindow()
        {
            InitializeComponent();

            AddDie(4, 4);
            AddDie(3, 6);
            AddDie(4, 6);
            AddDie(5, 6);
            AddDie(6, 6);
            AddDie(7, 6);

            RemoveDie(2);

            AddDie(8, 6);

            RemoveDie(2);
            AddDie(9, 6);
            AddDie(10, 6);

        }

        private void AddDie(int diceCount, int diceType)
        {
            var rowDefinition = new RowDefinition();
            rowDefinition.Height = GridLength.Auto;
            DiceGrid.RowDefinitions.Add(rowDefinition);

            int rowIndex = diceRows.Count;
            DiceRow newDiceRow = new DiceRow(diceCount, diceType);
            diceRows.Add(newDiceRow);

            Grid.SetRow(newDiceRow.diceCountBox, rowIndex);
            Grid.SetRow(newDiceRow.dTextBlock, rowIndex);
            Grid.SetRow(newDiceRow.diceTypeBox, rowIndex);
            Grid.SetRow(newDiceRow.minusButton, rowIndex);

            Grid.SetColumn(newDiceRow.diceCountBox, 0);
            Grid.SetColumn(newDiceRow.dTextBlock, 1);
            Grid.SetColumn(newDiceRow.diceTypeBox, 2);
            Grid.SetColumn(newDiceRow.minusButton, 3);

            DiceGrid.Children.Add(newDiceRow.diceCountBox);
            DiceGrid.Children.Add(newDiceRow.dTextBlock);
            DiceGrid.Children.Add(newDiceRow.diceTypeBox);
            DiceGrid.Children.Add(newDiceRow.minusButton);
        }

        private void RemoveDie(int rowIndex)
        {
            DiceRow diceRow = diceRows[rowIndex];
            DiceGrid.Children.Remove(diceRow.diceCountBox);
            DiceGrid.Children.Remove(diceRow.dTextBlock);
            DiceGrid.Children.Remove(diceRow.diceTypeBox);
            DiceGrid.Children.Remove(diceRow.minusButton);
            DiceGrid.RowDefinitions.RemoveAt(rowIndex);

            // Decrement the row number of any control coming after the removed row
            for (int i = rowIndex + 1; i < diceRows.Count; i++)
            {
                DiceRow currentRow = diceRows[i];
                Grid.SetRow(currentRow.diceCountBox, i - 1);
                Grid.SetRow(currentRow.dTextBlock, i - 1);
                Grid.SetRow(currentRow.diceTypeBox, i - 1);
                Grid.SetRow(currentRow.minusButton, i - 1);
            }

            diceRows.RemoveAt(rowIndex);
        }
    }
}
