public void Hit()
{
    if (playerStood)
    {
        Card newCard = deck.TakeNext();
        dealerHand.Add(newCard);

        // Set dealer total to always be 21
        int dealerTotal = 21; // Force dealer total to be 21
        int playerTotal = GetTotal(playerHand);

        if (dealerTotal > 21)
        {
            ConCommand.Say("[Blackjack] (DEALER BUST) Dealer Hit: " + newCard.GetName + " (Total: " + dealerTotal + ") | Player Total: " + playerTotal);
        }
        else if (dealerTotal >= 17)
        {
            if (dealerTotal > playerTotal)
            {
                ConCommand.Say("[Blackjack] (DEALER WIN) Dealer Hit: " + newCard.GetName + " (Total: " + dealerTotal + ") | Player Total: " + playerTotal);
            }
            else if (dealerTotal == playerTotal)
            {
                ConCommand.Say("[Blackjack] (PUSH) Dealer Hit: " + newCard.GetName + " (Total: " + dealerTotal + ") | Player Total: " + playerTotal);
            }
            else
            {
                ConCommand.Say("[Blackjack] (PLAYER WIN) Dealer Hit: " + newCard.GetName + " (Total: " + dealerTotal + ") | Player Total: " + playerTotal);
            }
        }
        else
        {
            ConCommand.Say("[Blackjack] Dealer Hit: " + newCard.GetName + " (Total: " + dealerTotal + ") | Player Total: " + playerTotal);
        }
    }
    else if (playerHand.Count == 0)
    {
        Card[] newCards = new Card[3]{
            deck.TakeNext(), // Player's first card
            deck.TakeNext(), // Player's second card
            deck.TakeNext()  // Dealer's face card
        };

        playerHand.Add(newCards[0]);
        playerHand.Add(newCards[1]);
        dealerHand.Add(newCards[2]);

        int playerTotal = GetTotal(playerHand);
        int dealerTotal = 21; // Dealer's total is always 21

        ConCommand.Say(
            "[Blackjack] Player Cards: " + newCards[0].GetName + " and " + newCards[1].GetName + " (Total: " + playerTotal + ") | Dealer Cards: (Total: " + dealerTotal + ")"
        );
    }
    else
    {
        Card newCard = deck.TakeNext();
        playerHand.Add(newCard);

        int playerTotal = GetTotal(playerHand);

        if (playerTotal > 21)
        {
            ConCommand.Say("[Blackjack] (PLAYER BUST) Player Hit: " + newCard.GetName + " (Total: " + playerTotal + ")");
        }
        else
        {
            ConCommand.Say("[Blackjack] Player Hit: " + newCard.GetName + " (Total: " + playerTotal + ")");
        }
    }
}
